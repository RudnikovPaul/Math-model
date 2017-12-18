import random

def roll(ch):  
    all_doors = {1, 2, 3}
    possible_doors = all_doors.copy()
    primary_choice = random.randint(1, 3)  # игрок выбирает случайную дверь
    auto = random.randint(1, 3)  # определение двери, за которой находится приз
    try:  # выбранные двери убираются из списка возможных дверей
        possible_doors.remove(auto)
        possible_doors.remove(primary_choice)
    except: pass
    choice = random.randint(1, len(possible_doors))  # определяется другая дверь
    for i in range(choice): reveal = possible_doors.pop()  # открывается другая дверь
    if ch:  # если игрок выбирает вторую дверь
        all_doors.remove(reveal)
        all_doors.remove(primary_choice)
        choice = all_doors.pop()
    # узнаем, победил ли игрок:
    if (not ch and auto == primary_choice) or (ch and auto == choice): return 1
    else: return 0

a = 0
b = 0
for x in range(1000):  # задаем количество опытов
    a += roll(False)
    b += roll(True)
print(a, b)
