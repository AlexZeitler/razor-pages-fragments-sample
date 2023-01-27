using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesFragments.Pages;

public class IndexModel : PageModel
{
  private readonly ILogger<IndexModel> _logger;
  public FragmentModel PageModel { get; set; } = null!;

  public IndexModel(
    ILogger<IndexModel> logger
  )
  {
    _logger = logger;
  }

  public void OnGet()
  {
    PageModel = new ParentModel(
      new List<ChildModel>()
      {
        new(1),
        new(2)
      }
    );
  }

  public void OnGetDetails(
    [FromQuery] int id
  )
  {
    PageModel = new ChildModel(id);
  }
}

public class FragmentModel
{
  public FragmentModel(
    string fragmentId
  )
  {
    FragmentId = fragmentId;
  }

  public string FragmentId { get; set; }
}

public class ChildModel : FragmentModel
{
  public int Id { get; }

  public ChildModel(
    int id
  ) : base("Detail")
  {
    Id = id;
  }
}

public class ParentModel : FragmentModel
{
  public List<ChildModel> Childs { get; }

  public ParentModel(
    List<ChildModel> childs
  ) : base("Full")
  {
    Childs = childs;
  }
}
