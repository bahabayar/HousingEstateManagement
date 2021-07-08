namespace HousingEstateManagement.SharedLibrary.Results
{
    public interface IDataResult<T>:IResult 
    {
        T Data { get; }
    }
}