namespace PizzaPerfect
{
  interface ITopping
  {
    string Name {get; }
    int LikeScale   { get; }
    bool IsVegetarian   { get; }
    bool IsMeat     { get; }
  }
}