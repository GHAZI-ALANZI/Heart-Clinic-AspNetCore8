namespace Heart_Clinic.Services
{
    interface IFunction<T>
    {
        void Add(T t);
        T Get(int id);
    }
}
