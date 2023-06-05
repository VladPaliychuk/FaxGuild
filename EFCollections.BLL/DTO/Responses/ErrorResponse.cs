using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCollections.BLL.DTO.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; } = new();

        public ErrorResponse(string error) =>
            Errors = new()
            {
                error
            };

        public ErrorResponse()
        {
        }
    }
}
