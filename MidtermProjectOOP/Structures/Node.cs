namespace MidtermProjectOOP.Models
{
    public class Node
    {
        public Student Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(Student data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
