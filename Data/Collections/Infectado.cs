using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace API.Data.Collections
{
    public class Infectado
    {
        public DateTime DataNascimento { get; set; }
        public String Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectado(DateTime dataNascimento, String sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}