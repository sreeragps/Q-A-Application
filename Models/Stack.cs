
namespace StackOverFlowProject.Models
{
    public class Stack
    {
        public Stack() { }
        public Stack(int stackid, string stackquestion, string stackanswer)
        {
            this.StackId = stackid;
            this.StackQuestion = stackquestion;
            this.StackAnswer = stackanswer;
        }
        public int StackId { get; set; }
        public string StackQuestion
        {
            get; set;
        }

        public string StackAnswer
        {
            get; set;
        }
    }
}