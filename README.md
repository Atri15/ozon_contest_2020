# ozon_contest_2020
##Отбор на Школу Go разработки Ozon

Мои решения задач для соревнований.


##Задача: B.Теги
- Компилятор: make2
- Вердикт: OK
- Статус: Полное решение
```
SELECT g.id, g.name
FROM goods g 
 JOIN tags_goods tg
	ON tg.goods_id = g.id
 JOIN tags t
	ON t.id = tg.tag_id
GROUP BY g.id, g.name
HAVING count(t.id) = (SELECT count(id) FROM tags)
```
