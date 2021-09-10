namespace MishaTelecoms.Domain.Data
{
    // Dynamically create parameters for sql statements
    public class ParameterInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public object DefaultValue { get; set; }
    }
}
