def sort_by_strange_min(a):
    for i in range(len(a)):
        for j in range(i + 1, len(a)):
            m = min(min(a[i]), min(a[j])) #ищем наименьшее среди 4 значений
            #если это упаковка первого или доставка последнего - все  ок, иначе свап
            #нужно потому что пока пакуют первый подарок - поростой, пока доставляют
            # последний - простой. По сути, сортируем типа с двух сторон
            if not (m == a[i][0] or m == a[j][1]):
                a[i], a[j] = a[j], a[i]
    return a


def delivery_time(a):
    a = sort_by_strange_min(a)
    s1 = s2 = 0
    for i in range(len(a)): #где сумма больше на доставке или на упаковке
        # и обязательно + последняя доставка
        s1 += a[i][0]
        s2 = max(s1, s2) + a[i][1]
    return s2

print(delivery_time([[4, 5], [4, 1], [30, 4], [6, 30], [2, 3]]))
print(delivery_time([[3, 5], [4, 6], [2, 7]]))
print(delivery_time([[1, 2], [2, 3], [3, 4]]))
