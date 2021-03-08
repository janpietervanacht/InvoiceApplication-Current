using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Country
    {
        public int Id { get; set; }  // [Required is niet nodig bij Id

        [Required]
        [DisplayName("Iso Code land:")]
        public string CountryIsoCode { get; set; }

        [Required]
        [DisplayName("Omschrijving land:")]
        public string CountryDescription { get; set; }

    }
}
