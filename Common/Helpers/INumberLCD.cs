namespace Common.Helpers
{
    public interface INumberLCD
    {
        string LCDtoNumber(string[] code);

        string NumberToLCD(int number);
    }
}