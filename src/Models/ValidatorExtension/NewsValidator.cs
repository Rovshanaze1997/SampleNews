using FluentValidation;

namespace News.Models.ValidatorExtension
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(n => n.Categories).NotEmpty().WithMessage("Kateqoriya secimi bos ola bilmez");
            RuleFor(n => n.Content).NotEmpty().WithMessage("Mezmun daxil etmelisiniz").Length(2, 100)
                .WithMessage("En az 2 en cox ise 100 karakter daxil ede bilersiniz");
            RuleFor(n => n.Description).NotEmpty().WithMessage("Qisa metn elave etmelisiniz");
            RuleFor(n => n.PicUrl).NotEmpty().WithMessage("Sekil bos ola bilmez");
            RuleFor(n => n.DatePosted).NotEmpty().WithMessage("Tarix duzgun qeyd olunmayib");
            RuleFor(n => n.Name).NotEmpty().WithMessage("Xeber adi bos ola bilmez");
        }
    }
}