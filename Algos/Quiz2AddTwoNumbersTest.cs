using System.Numerics;

namespace Algos;

public class Quiz2AddTwoNumbersTest
{
    [Fact]
    public void Test1()
    {
        var one = new ListNode(2, new ListNode(4, new ListNode(3)));
        var two = new ListNode(5, new ListNode(6, new ListNode(4)));
        var expected = new ListNode(7, new ListNode(0, new ListNode(8)));

        var res = new Quiz2AddTwoNumbers().AddTwoNumbers(one, two);

        Assert.Equivalent(expected, res);
    }
}

public class Quiz2AddTwoNumbers
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var cal1 = Calc(l1).Reverse().ToInt();
        var cal2 = Calc(l2).Reverse().ToInt();
        var sum = cal1 + cal2;

        return sum.ToString().ToStringArray().Reverse().ToListNode();
    }

    private static string[] Calc(ListNode node, string tot = "")
    {
        string inter = tot;
        inter += node.val;

        if (node.next != null)
            return Calc(node.next, inter);

        return inter.ToStringArray();
    }
}

public static class AddTwoNumbersExtensions
{
    public static BigInteger ToInt(this IEnumerable<string> arr)
    {
        var res = "";
        arr.ToList().ForEach(x => res += x);
        return BigInteger.Parse(res);
    }

    public static ListNode ToListNode(this IEnumerable<string> arr)
    {
        var list = arr.ToList();
        var first = list.Last();
        list.RemoveAt(list.Count - 1);

        var firstNode = new ListNode(int.Parse(first));

        return CalculateNode(list, firstNode);
    }

    internal static string[] ToStringArray(this string val) =>
        val.Select(x => x.ToString()).ToArray();

    private static ListNode CalculateNode(
        this List<string> arr,
        ListNode prev)
    {
        if (arr.Count == 0)
            return prev;
        
        var last = arr.Last();
        arr.RemoveAt(arr.Count - 1);

        return CalculateNode(arr, new ListNode(int.Parse(last), prev));
    }
}

// Provided by LeetCode
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}