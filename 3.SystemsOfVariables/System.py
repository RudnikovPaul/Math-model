import random
import math

# генератор равномерно распределенных случайных чисел
def Rand (RowList, Value):
    x = random.uniform(0.0, 1.0)
    if (x <= RowList[0]):
        return Value[0]
    elif (x > RowList[0] and x < RowList[0] + RowList[1]):
        return Value[1]
    else:
        return Value[2]

# сумма матрицы по столбцам либо строкам
def Series (matrix, dir):
    result = []
    for i in range (3):
        sir = 0
        for j in range (3):
            if (dir):
                sir = sir + matrix[i][j]
            else:
                sir = sir + matrix[j][i]
        result.append(sir)
    return result

# математическое ожидание для одного списка и дисперсия
def MathAndDis (Value, RowList, dir):
    resultL = 0
    resultM = 0
    for i in range (3):
        resultL += Value[i] ** 2 * RowList[i]
        resultM += Value[i] * RowList[i]
    if (dir):
        MX = resultM
    else:
        MY = resultM
    resultD = resultL - resultL ** 2
    return resultM, resultD

# математическое ожидание для двух списков
def MathXY (XValues, YValues, ProbMatrix):
    result = 0
    for i in range(3):
        for j in range(3):
            result += XValues[i] * YValues[j] * ProbMatrix[i][j]
    MXY = result
    return result

# определение плотности распределения для одного списка
def Density (XY,  dir):
    resultList = []
    for i in range(3):
        resultList.append(0)
    for value in XY:
        if (dir):
            if (value == 7.3):
                resultList[0] += 1
                break
            if (value == 9):
                resultList[1] += 1
                break
            if (value == 13.8):
                resultList[2] += 1
                break
    return resultList

# определение плотности распределения для двух списков
def XYDensity (XY, Xvalue, YValue):
    resultXYList = []
    for i in range (9):
        resultXYList.append(0)
    for i in range (0, len(XY), 2):
        x = XY[i]
        y = XY[i + 1]
        for q in range (3):
            if x == Xvalue[q]:
                if y == YValue[0]:
                    resultXYList[q * 3] += 1
                elif y == YValue[1]:
                    resultXYList[q * 3 + 1] += 1
                else:
                    resultXYList[q * 3 + 2] += 1
    return resultXYList

# Распределение
def Distribution (Density, valueList, chartName):
    print(chartName + ": ")
    for i in range(len(Density)):
        print(str(valueList[i]) + "   " + str(Density[i]))



# задаем начальные значения:
MX = 0
MY = 0
MXY = 0

ProbMatrix = [[0.13, 0.13, 0.04], [0.04, 0.12, 0.14], [0.12, 0.22, 0.06]]
Xvars = [7.3, 9, 13.8]
Yvars = [0.2, 2.6, 6.4]
coordinates = []
XRowList = Series(ProbMatrix, True)
YRowList = Series(ProbMatrix, False)

# генерируем случайные числа
for x in range(1000):
    coordinates.append(Rand(XRowList, Xvars))
    coordinates.append(Rand(YRowList, Yvars))

# вывод значений оценок
maths, disp = MathAndDis (Xvars, XRowList, True)
print ("M(X)  = " + str(maths))
print ("D(X)  = " + str(disp))
maths, disp = MathAndDis (Yvars, YRowList, True)
print ("M(Y)  = " + str(maths))
print ("D(Y)  = " + str(disp))
print ("M(XY) = " + str(MathXY(Xvars, Yvars, ProbMatrix)))
print ("corr  = " + str(MXY - MX * MY))

Distribution(Density(coordinates, True), Xvars, "Распределение X")
Distribution(Density(coordinates, False), Yvars, "Распределение Y")
Density = XYDensity(coordinates, Xvars, Yvars)

# распределение XY
XYvars = ["7.3|0.2", "7.3|2.6", "7.3|6.4", "9|0.2", "9|2.6", "9|6.4", "13.8|0.2", "13.8|2.6", "13.8|6.4"]
print( "Плотность XY:")
for i in range (len(Density)):
    print(str(XYvars[i]) + "   " + str(Density[i]))