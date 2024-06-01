import pyodbc
import re
from collections import Counter
from flask import Flask, jsonify
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB

app = Flask(__name__)
# Establecer la conexión con la base de datos SQL Server
server = 'tcp:estacnacs2.database.windows.net'
database = 'EsTacna-Cs2'
driver = '{ODBC Driver 18 for SQL Server}'
cnxn = pyodbc.connect(f'Driver=ODBC Driver 18 for SQL Server;Server=tcp:estacnacs2.database.windows.net,1433;Database=EsTacna-Cs2;Uid=administrador;Pwd=Upt2024*;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;')


# Definir la ruta del endpoint
@app.route('/api/recomendaciones', methods=['GET'])
def obtener_recomendaciones():
    cursor = cnxn.cursor()
    # Obtención de los comentarios y el id del establecimiento y usuario asociados a cada uno de ellos
    cursor.execute('SELECT establecimiento_id, usuario_id, comentario FROM Valoracion')
    comentarios = cursor.fetchall()

    # Crear un diccionario para almacenar las palabras clave asociadas a cada establecimiento
    palabras_clave_por_establecimiento = {}

    # Iterar sobre los resultados para procesar los comentarios y encontrar las palabras clave asociadas a cada establecimiento
    for resultado in comentarios:
        establecimiento_id = resultado[0]
        comentario = resultado[2]

        # Eliminar los caracteres especiales y convertir el comentario a minúsculas
        comentario = re.sub(r'[^\w\s]', '', comentario)
        comentario = comentario.lower()

        # Separar el comentario en palabras
        palabras = comentario.split()

        # Contar la frecuencia de ocurrencia de cada palabra en el comentario
        contador_palabras = Counter(palabras)

        # Seleccionar las palabras con una frecuencia más alta como palabras clave
        palabras_clave = [palabra for palabra, frecuencia in contador_palabras.most_common(5)]

        # Agregar las palabras clave al diccionario asociado al establecimiento correspondiente
        if establecimiento_id in palabras_clave_por_establecimiento:
            palabras_clave_por_establecimiento[establecimiento_id].extend(palabras_clave)
        else:
            palabras_clave_por_establecimiento[establecimiento_id] = palabras_clave

    # Procesamiento de los comentarios y almacenamiento en un diccionario asociado a cada establecimiento
    comentarios_por_establecimiento = {}
    for establecimiento_id, usuario_id, comentario in comentarios:
        # Eliminación de caracteres especiales y conversión a minúsculas
        comentario_procesado = ''.join(c for c in comentario if c.isalnum() or c.isspace()).lower()
        # Agregado del comentario procesado al diccionario asociado al establecimiento correspondiente
        if establecimiento_id in comentarios_por_establecimiento:
            comentarios_por_establecimiento[establecimiento_id].append(comentario_procesado)
        else:
            comentarios_por_establecimiento[establecimiento_id] = [comentario_procesado]

    # Entrenamiento del modelo de clasificación utilizando todos los comentarios
    comentarios_etiquetados = [(comentario, establecimiento_id) for establecimiento_id in
                               comentarios_por_establecimiento
                               for comentario in comentarios_por_establecimiento[establecimiento_id]]
    comentarios_entrenamiento, etiquetas_entrenamiento = zip(*comentarios_etiquetados)
    vectorizador = CountVectorizer()
    matriz_caracteristicas = vectorizador.fit_transform(comentarios_entrenamiento)
    modelo_clasificacion = MultinomialNB()
    modelo_clasificacion.fit(matriz_caracteristicas, etiquetas_entrenamiento)

    # Obtención de los usuarios
    cursor.execute('SELECT DISTINCT usuario_id FROM Valoracion')
    usuarios = cursor.fetchall()

    # Generación de recomendaciones personalizadas para cada usuario
    Datos = {}
    for usuario in usuarios:
        usuario_id = usuario[0]

        # Obtención de los comentarios y el establecimiento asociado a cada uno de ellos para el usuario
        cursor.execute('SELECT comentario, establecimiento_id FROM Valoracion WHERE usuario_id = ?', usuario_id)
        comentarios_usuario = cursor.fetchall()

        # Procesamiento de los comentarios del usuario y almacenamiento en un diccionario asociado a cada establecimiento
        comentarios_por_establecimiento_usuario = {}
        for comentario, establecimiento_id in comentarios_usuario:
            # Eliminación de caracteres especiales y conversión a minúsculas
            comentario_procesado = ''.join(c for c in comentario if c.isalnum() or c.isspace()).lower()
            # Agregado del comentario procesado al diccionario asociado al establecimiento correspondiente
            if establecimiento_id in comentarios_por_establecimiento_usuario:
                comentarios_por_establecimiento_usuario[establecimiento_id].append(comentario_procesado)
            else:
                comentarios_por_establecimiento_usuario[establecimiento_id] = [comentario_procesado]

        # Obtención del término de búsqueda del usuario
        cursor.execute('SELECT termino_busqueda FROM Busqueda WHERE usuario_id = ?', usuario_id)
        termino_busqueda_usuario = cursor.fetchone()[0]

        # Utilizar los establecimientos relevantes en la generación de recomendaciones personalizadas
        establecimientos_relevantes = []
        for establecimiento_id in palabras_clave_por_establecimiento:
            palabras_clave = palabras_clave_por_establecimiento[establecimiento_id]
            for palabra in palabras_clave:
                if palabra in termino_busqueda_usuario:
                    establecimientos_relevantes.append(establecimiento_id)
                    break

        # Generación de recomendaciones personalizadas utilizando los establecimientos relevantes
        ids_establecimientos_relevantes = []
        for establecimiento_id in establecimientos_relevantes:
            if establecimiento_id in comentarios_por_establecimiento_usuario:
                comentarios_establecimiento = comentarios_por_establecimiento_usuario[establecimiento_id]
                matriz_caracteristicas_item = vectorizador.transform(comentarios_establecimiento)
                vector_probabilidades = modelo_clasificacion.predict_proba(matriz_caracteristicas_item)[:,
                                        modelo_clasificacion.classes_.tolist().index(establecimiento_id)]
                probabilidad_promedio = vector_probabilidades.mean()
                ids_establecimientos_relevantes.append((probabilidad_promedio, establecimiento_id))
        ids_items_relevantes_ordenados = sorted(ids_establecimientos_relevantes, reverse=True)[
                                         :3]  # Selección de los 3 items más relevantes
        ids_relevantes = [establecimiento_id for _, establecimiento_id in ids_items_relevantes_ordenados]
        # Generar un diccionario con los datos
        Datos[usuario_id] = ids_relevantes
    # Formatear la respuesta
    respuesta = Datos

    # Retornar la respuesta en formato JSON
    return jsonify(respuesta)

if __name__ == '__main__':
    app.run()