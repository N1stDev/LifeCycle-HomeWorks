using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

enum ClothesSize
{
    XXS = 32,
    XS = 34,
    S = 36,
    M = 38,
    L = 40
}

static class ClothesSizeExtensions
{
    public static string GetDescription(this ClothesSize size)
    {
        if ((int)size >= (int)ClothesSize.S)
        {
            return "Взрослый размер";
        }

        return "Детский размер";
    }
}

interface IMaleClothes
{
    public string DressUpMale();
}

interface IFemaleClothes
{
    public string DressUpFemale();
}

abstract class Clothes
{
    public ClothesSize size;
    public float price;
    public string color;

    public Clothes(ClothesSize size, float price, string color)
    {
        this.size = size;
        this.price = price;
        this.color = color;
    }

    protected string GetInfo()
    {
        return String.Format("Размер: {0} - {1}\nЦена: {2} руб.\nЦвет: {3}\n", size, size.GetDescription(), price, color);
    }
}

class TShirt : Clothes, IFemaleClothes, IMaleClothes
{
    public TShirt(ClothesSize size, float price, string color) : base(size, price, color)
    { }  

    public string DressUpMale()
    {
        return "Тип одежды: мужская футболка\n" + GetInfo();
    }

    public string DressUpFemale()
    {
        return "Тип одежды: женская футболка\n" + GetInfo();
    }
}

class Pants : Clothes, IFemaleClothes, IMaleClothes
{
    public Pants(ClothesSize size, float price, string color) : base(size, price, color)
    { }

    public string DressUpMale()
    {
        return "Тип одежды: мужские штаны\n" + GetInfo();
    }

    public string DressUpFemale()
    {
        return "Тип одежды: женские штаны\n" + GetInfo();
    }
}

class Skirt : Clothes, IFemaleClothes
{
    public Skirt(ClothesSize size, float price, string color) : base(size, price, color)
    { }

    public string DressUpFemale()
    {
        return "Тип одежды: Юбка\n" + GetInfo();
    }
}

class Tie : Clothes, IMaleClothes
{
    public Tie(ClothesSize size, float price, string color) : base(size, price, color)
    { }

    public string DressUpMale()
    {
        return "Тип одежды: Галстук\n" + GetInfo();
    }
}

class Atelier
{
    public string DressUpMale(List<Clothes> clothes)
    {
        StringBuilder result = new StringBuilder();
        result.Append("КАТАЛОГ МУЖСКОЙ ОДЕЖДЫ:\n");

        foreach (Clothes c in clothes)
        {
            if (c is IMaleClothes)
            {
                result.Append("\n" + ((IMaleClothes)c).DressUpMale());
            }
        }

        return result.ToString();
    }

    public string DressUpFemale(List<Clothes> clothes)
    {
        StringBuilder result = new StringBuilder();
        result.Append("КАТАЛОГ ЖЕНСКОЙ ОДЕЖДЫ:\n");

        foreach (Clothes c in clothes)
        {
            if (c is IFemaleClothes)
            {
                result.Append("\n" + ((IFemaleClothes)c).DressUpFemale());
            }
        }

        return result.ToString();
    }
}

class Program
{
    static void Main()
    {
        List<Clothes> clothes = new List<Clothes>();

        #region Добавляем в список одежду
        clothes.Add(new TShirt(ClothesSize.XXS, 500, "красный"));
        clothes.Add(new TShirt(ClothesSize.XS, 550, "фиолетовый"));
        clothes.Add(new TShirt(ClothesSize.S, 680, "желтый"));
        clothes.Add(new TShirt(ClothesSize.L, 2500, "голубой"));

        clothes.Add(new Pants(ClothesSize.XXS, 1928, "бежевый"));
        clothes.Add(new Pants(ClothesSize.S, 4034, "болотный"));
        clothes.Add(new Pants(ClothesSize.M, 4245, "индиго"));
        clothes.Add(new Pants(ClothesSize.L, 7659, "темный индиго"));

        clothes.Add(new Skirt(ClothesSize.S, 890, "розовый"));
        clothes.Add(new Skirt(ClothesSize.M, 1234.70f, "черный"));

        clothes.Add(new Tie(ClothesSize.S, 7229.90f, "в горошек"));
        clothes.Add(new Tie(ClothesSize.M, 6735.50f, "синий"));
        #endregion

        Atelier atelier = new Atelier();

        Console.WriteLine(atelier.DressUpMale(clothes));
        Console.WriteLine(atelier.DressUpFemale(clothes));
    }
}