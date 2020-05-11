namespace RuletaWebApi.Entidades.Entidades
{
    public class RuletaEstado
    {
        public int Id { get; private set; }
        public string Estado { get; private set; }

        public RuletaEstado(int id, bool estado)
        {
            this.Id = id;
            this.Estado =  estado ? "Habilitada": "Deshabilitada";
        }
    }
}