using RenameRuleContract;
using System.Text.Json.Nodes;

namespace BatchRename
{
    public class OrderRuleParser : IRenameRuleParser
    {
        public string getName()
        {
            return "Order";
        }

        public IRenameRule Parse(JsonNode obj)
        {
            int start = (int)obj["start"];
            int digit = (int)obj["digit"];

            return new OrderRule(start, digit);
        }

        public object ParseRuleToFileObject(IRenameRule rule)
        {
            var orderRule = rule as OrderRule;
            var obj = new
            {
                type = orderRule?.Name,
                start = orderRule?.StartValue,
                digit = orderRule?.Padding,
            };
            return obj;
        }
    }
}