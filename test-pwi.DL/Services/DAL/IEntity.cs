namespace test_pwi.DL.Services.DAL
{
    public interface IEntity
    {
        //Funiona como um contrato que obriga todas as entidades que implementam esta interface devem possuir um campo id do tipo long
        //Para que seja possivel reutilizar o codigo do GenericRepository para todas as entidades do codigo, pois todas herdam do mesmo tipo (IEntity)
        long Id { get; set; }
    }
}