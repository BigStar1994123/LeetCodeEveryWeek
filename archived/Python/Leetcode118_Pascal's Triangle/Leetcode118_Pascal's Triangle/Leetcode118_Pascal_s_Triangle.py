from math import cos, radians

# Create a string with spaces proportional to a cosine of x in degrees
def make_dot_string(x):
    rad = radians(x)                             # cos works with radians
    numspaces = int(20 * cos(radians(x)) + 20)   # scale to 0-40 spaces
    st = ' ' * numspaces + 'o'                   # place 'o' after the spaces
    return st

def main():
    for i in range(0, 1800, 12):
        s = make_dot_string(i)
        print(s)


def generate(numRows):
    """
    :type numRows: int
    :rtype: List[List[int]]
    """
    retList = []

    for i in range(1,numRows + 1):
        if i == 1:
            retList.append([1])
            continue

        list = [1]
        lastList = retList[len(retList) - 1]
        for k in range(0, len(lastList) - 1):
            list.append(lastList[k] + lastList[k+1])

        list.append(1)
        retList.append(list)

    return retList
        

a = generate(5)
print(a)