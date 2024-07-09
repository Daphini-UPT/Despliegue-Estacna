namespace EsTacna.Models
{

    /**
    * Modelo para representar los errores en la aplicación.
    */
    public class ErrorViewModel
    {
        /**
        * Id de la solicitud que generó el error.
        */
        public string? RequestId { get; set; }

        /**
        * Indica si se debe mostrar el id de la solicitud en la interfaz.
        */
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
