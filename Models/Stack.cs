
namespace StackOverFlowProject.Models{
 public class Stack
    {  
        public Stack(){}
        public Stack(string stackquestion,string stackanswer)
        {
         this.StackQuestion=stackquestion;
         this.StackAnswer=stackanswer;
        }
         
        public string StackQuestion
        {
            get;set;
        }
        
        public string StackAnswer
        {
            get;set;
        }
    }
}