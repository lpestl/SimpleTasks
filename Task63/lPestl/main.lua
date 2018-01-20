-- Наибольший общий делитель НОД
-- реализация алгоритма Евклида
function gcd(a, b)
  if b == 0 then
    return a
  end
  return gcd(b, a % b)
end

-- Наименьшее общее кратное НОК
-- связь с НОД (вычисление через НОД)
function lcm(a, b)
  return math.abs(a * b) / gcd(a, b)
end

-- НОК для массива чисел
function lcm_array(arr)
  -- Если количество элементов в массиве меньше 2, то
  -- прои кол.ел. == 0 возвращается nil
  -- а при кол.ед == 1 возвращается первый элемент
  if #arr < 2 then
    return arr[1]
  end
  -- идея заключается в использовании свойства ассоциативности
  res = arr[1]
  for i = 2, #arr do
    res = lcm(res, arr[i])
  end
  return res
end

-- Тест 1
A = { }
print(lcm_array(A))
-- Тест 2
A = { 5 }
print(lcm_array(A))
-- Тест 3
A = { 2, 3 }
print(lcm_array(A))
-- Тест 4
A = { 2, 3, 4 }
print(lcm_array(A))
-- Тест 5
A = { 5, 4, 20, 2 }
print(lcm_array(A))
-- Тест 6
A = { 1, 1, 2, 3, 5, 8, 13, 21, 34 }
print(lcm_array(A))