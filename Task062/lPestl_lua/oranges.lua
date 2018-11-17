-- Функция подсчета изначального количества апельсинов
function getCountOranges(m)
  -- Если m < 4 (или 3), то условия задачи не будут выполняться
  if m < 4 then --или if m < 3 , в зависимости от трактовки условия задачи
    -- то решения не существует
    return -1
  -- иначе, проверяем условия задачи
  else 
    i = 1
    -- Будем искать до тех пор пока условия НЕ ВЫПОЛНЯЮТСЯ
    while i % m ~= (m - 1) or         -- апельсины по m штук в каждый пакет, но не получилось, на один из пакетов пришелся m-1 апельсин
          i % (m - 1) ~= (m - 2) or   -- попробовали положить по m-1 апельсина, то осталось m-2
          i % (m - 2) ~= (m - 3) do   -- разложить по m-2 апельсина, осталось m-3
      -- Из условия "Попробовали положить по 2 апельсина, остался 1" ясно, что искомое число - нечетное
      i = i + 2
    end  
    return i
  end
end

-----------------------------------
--            Тест 1             --
m = 4
print(getCountOranges(m))
--            Тест 2             --
m = 5
print(getCountOranges(m))
--            Тест 3             --
m = 6
print(getCountOranges(m))
--            Тест 4             --
m = 7
print(getCountOranges(m))
--            Тест 5             --
m = 8
print(getCountOranges(m))
--            Тест 6             --
m = 9
print(getCountOranges(m))
--            Тест 7             --
m = 10
print(getCountOranges(m))
--            Тест 8             --
m = 1000
print(getCountOranges(m))