using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        // AboutController sınıfının yapıcı metodu
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        // Hakkımda bilgilerini listeleyen metot
        [HttpGet]
        public IActionResult AboutList()
        {
            // Tüm Hakkımda bilgilerini alır ve başarı durumunda döner
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        // Yeni bir Hakkımda bilgisi oluşturan metot
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            // Gelen CreateAboutDto nesnesi kullanılarak yeni bir About nesnesi oluşturulur
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };

            // About nesnesi servis aracılığıyla eklenir ve başarı durumunda döner
            _aboutService.TAdd(about);
            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        // Hakkımda bilgisini silen metot
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            // Verilen ID'ye sahip Hakkımda bilgisini servis aracılığıyla alır
            var value = _aboutService.TGetByID(id);

            // Alınan Hakkımda bilgisi servis aracılığıyla silinir ve başarı durumunda döner
            _aboutService.TDelete(value);
            return Ok("Hakkımda Alanı Silindi");
        }

        // Hakkımda bilgisini güncelleyen metot
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            // Gelen UpdateAboutDto nesnesi kullanılarak güncelleme yapılacak About nesnesi oluşturulur
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                ImageUrl = updateAboutDto.ImageUrl,
                Description = updateAboutDto.Description,
                Title = updateAboutDto.Title
            };

            // About nesnesi servis aracılığıyla güncellenir ve başarı durumunda döner
            _aboutService.TUpdate(about);
            return Ok("Hakkımda Alanı Güncellendi");
        }

        // Belirli bir Hakkımda bilgisini getiren metot
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            // Verilen ID'ye sahip Hakkımda bilgisini servis aracılığıyla alır ve başarı durumunda döner
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
