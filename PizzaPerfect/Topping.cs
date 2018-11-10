namespace PizzaPerfect
{
  public class Topping //: ITopping
  {
    public string Name {get; private set;}
    public int LikeScale   { get; private set;}
    public bool IsVegetarian   { get; private set;}
    public bool IsMeat     { get; private set;}

    public Topping(string name, int likeScale, bool isVegetarian, bool isMeat)
    {
      Name = name;
      LikeScale = likeScale;
      IsVegetarian = isVegetarian;
      IsMeat = isMeat;
    }
  }
}