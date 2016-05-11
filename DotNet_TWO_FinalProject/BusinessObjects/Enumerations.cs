namespace BusinessObjects
{
    public enum Active
    {
        active = 0,
        inactive,
        all
    }

    public enum Roles
    {
        RentalAgent = 0,
        CheckOut,
        CheckIn,
        Maintenance,
        Prep,
        Manager,
        Admin = 999
    }
}