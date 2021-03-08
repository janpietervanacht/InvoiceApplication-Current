namespace Model.ConstantsAndEnums
{
    public enum ActionCode  // voor een dropdownlist bij Wijzig Client
    {
        A, 
        I
    }

    public enum ClientAgeEnum
    // hiermee voorkom je magic strings
    {
        Kind=10, 
        Volwassene=20, 
        Bejaarde=30   
    }  

    public enum SizeOfClientEnum
    {
        Big,
        Small 
    }

    public enum TypeOfExport
    {
        XML,
        JSON
    }
}
