namespace Schulmuseum.Models;

public class BlogPost
{
    public int Id { get; set; }
    public int Status { get; set; }
    public int CategoryId { get; set; }
    public int CreatorId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? TitleImage { get; set; }
    
    public string? Date { get; set; }
    public string? Content { get; set; }
}


/*
Status:
    - -1: Nicht genehmigt(muss überarbeitet werden) 
    -  0: Noch nicht genehmigt 
    -  1: Genehmigt
    -  2: wird bearbeitet   (verboten)
    - 31: Wird korrigiert   (Nicht genehmigt) von der Lehrperson
    - 32: Wird bearbeitet   (Nicht genehmigt) vom Schüler
    - 41: Wird korrigiert   (Genehmigt)
    - 42: Wird bearbeitet   (Genehmigt)
    -  5: Qualified by admin
*/