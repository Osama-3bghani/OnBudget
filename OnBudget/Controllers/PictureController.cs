using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBudget.BL.DTOs.PictureDtos;
using OnBudget.BL.Services.PictureService;

namespace OnBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class PicturesController : ControllerBase
        {
            private readonly IPictureService _pictureService;

            public PicturesController(IPictureService pictureService)
            {
                _pictureService = pictureService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<ReadPictureDto>>> GetAllPicturesAsync()
            {
                var pictures = await _pictureService.GetAllPicturesAsync();
                return Ok(pictures);
            }

            [HttpPost]
            public async Task<ActionResult<int>> AddPictureAsync(WritePictureDto writePictureDto)
            {
                var pictureId = await _pictureService.AddPictureAsync(writePictureDto);
                return Ok(pictureId);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> UpdatePictureAsync(int id, WritePictureDto writePictureDto)
            {
                await _pictureService.UpdatePictureAsync(id, writePictureDto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> RemovePictureAsync(int id)
            {
                await _pictureService.RemovePictureAsync(id);
                return NoContent();
            }
        }
    }

