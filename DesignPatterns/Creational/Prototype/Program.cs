namespace Prototype;

internal class Program
{
    private static void Main(string[] args)
    {
        unsafe
        {
            var manager = new Manager("John Doe");
            var managerClone = manager.Clone();
            var managerPointer = &manager;
            var managerClonePointer = &managerClone;

            Console.WriteLine(manager.Name);
            Console.WriteLine(managerClone.Name);
            Console.WriteLine((int)managerPointer);
            Console.WriteLine((int)managerClonePointer);

            var employee = new Employee(manager, "Kevin");
            var employeeClone = (Employee)employee.Clone();
            Console.WriteLine("Shallow copy");
            Console.WriteLine(employeeClone.Name);
            Console.WriteLine(employeeClone.Manager.Name);

            employeeClone.Manager.Name = "ChangedName";
            //with shallow copy employee manager refers to manager
            Console.WriteLine(manager.Name);

            manager = new Manager("John Doe");

            Console.WriteLine("Deep clone");

            var deepClonedManager = manager.DeepClone();

            deepClonedManager.Name = "new name";

            //with deep clone managers are different refences
            Console.WriteLine(manager.Name);
            Console.WriteLine(deepClonedManager.Name);
        }
    }
}