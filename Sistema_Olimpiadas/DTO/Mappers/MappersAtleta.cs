using LogicaNegocio.EntidadesDominio;

namespace DTO.Mappers
{
    public class MappersAtleta
    {
        public static Atleta FromDTO(ListadoAtletasDTO dto)
        {
            if (dto != null)
            {
                Atleta atleta = new Atleta
                {
                    IdDisciplinas = dto.IdDisciplinas,
                    Disciplinas = new List<Disciplina>()
                };
                atleta.Id = dto.IdAtleta;
                return atleta;
            }
            return null;
        }

        public static ListadoAtletasDTO FromAtleta(Atleta atleta)
        {
            ListadoAtletasDTO dto = new ListadoAtletasDTO()
            {
                IdAtleta = atleta.Id,
                NombreAtleta = atleta.Nombre,
                ApellidoAtleta = atleta.Apellido,
                SexoAtleta = atleta.EsMasculino,
                NombrePais = atleta.Pais.Nombre,
                IdDisciplina = atleta.IdDisciplina
            };
            return dto;
        }

        public static IEnumerable<ListadoAtletasDTO> FromAtletas(IEnumerable<Atleta> atletas)
        {
            List<ListadoAtletasDTO> dtos = new List<ListadoAtletasDTO>();

            foreach (Atleta item in atletas)
            {
                dtos.Add(FromAtleta(item));
            }
            return dtos;
        }
    }
}

