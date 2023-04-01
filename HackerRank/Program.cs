static int diagonalDifference(List<List<int>> arr)
{
    int diagonalOne = 0;
    int diagonalTwo = 0;
    int result = 0;
    for (int i = 0; i < arr.Count; i++)
    {
        diagonalOne += arr[i][i];
        diagonalTwo += arr[i][arr.Count - i - 1];
    }
    result = diagonalOne - diagonalTwo;
    return Math.Abs(result);
}
static List<int> compareTriplets(List<int> a, List<int> b) => 
     new List<int>() { a.Where((val, index) => val > b[index]).Count(), b.Where((val, index) => val > a[index]).Count() };
static long aVeryBigSum(List<long> ar) =>
        ar.Sum();
static List<int> compareTripletsLong(List<int> a, List<int> b)
{
    int alicePoints = 0;
    int bobPoints = 0;
    for (int i = 0; i < a.Count; i++)
    {
        if (a[i] > b[i])
        {
            alicePoints++;
        }
        else if (a[i] < b[i])
        {
            bobPoints++;
        }
    }
    return new List<int>() { alicePoints, bobPoints };
}
static List<int> reverseArray(List<int> a)
{
    a.Reverse();
    return a;
}
// sum of array
static int simpleArraySum(List<int> ar) =>
  ar.Sum();
