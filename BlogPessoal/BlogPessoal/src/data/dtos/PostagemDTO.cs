using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.data.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar uma nova postagem</para>
    /// <para>Criado por: Lethicya Lopes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class NovaPostagemDTO
    {
        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public string Foto { get; set; }

        public string EmailCriador { get; set; }

        [Required]
        public int DescricaoTema { get; set; }

        public NovaPostagemDTO(string titulo, string descricao, string foto, string emailCriador, int descricaoTema)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            EmailCriador = emailCriador;
            DescricaoTema = descricaoTema;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para alterar uma nova postagem</para>
    /// <para>Criado por: Lethicya Lopes</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 29/04/2022</para>
    /// </summary>
    public class AtualizarPostagemDTO
    {
        [Required]
        [StringLength(30)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public string Foto { get; set; }

        [Required]
        public int DescricaoTema { get; set; }

        public AtualizarPostagemDTO(string titulo, string descricao, string foto, int descricaoTema)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DescricaoTema = descricaoTema;
        }
    }
}
