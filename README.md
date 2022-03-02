Ход решения:
	Все геометрические фигуры сильно отличаются между собой - имеют разные формы, разное количество сторон и, соответственно, любые вычисления с разными фигурами производятся по-разному. Поэтому единственное, чем я решил объединить фигуры Круга и Треугольника (и любых других фигур, которые планируется добавлять в будущем) - интерфейсом IGeometricShape, который обязывает наследника реализовать метод GetArea().
	У классов Triangle и Circle созданы конструкторы, принимающие свои необходимые аргументы (радиус и 3 стороны треугольника). Без этих базовых параметров фигуры Треугольника и Круга не могут существовать.
	В самих конструкторах есть несколько примитивных проверок на входящие значения. Не уверен насколько правильно подобраны типы выдаваемых исключений, но в представление в моей голове они вписываются более-менее нормально)
	
По поставленным задачам:
1. Сама библиотека с необходимым функционалом реализована.
2. Вычисление площади фигуры без знания типа фигуры в compile-time - насколько я понимаю формулировку, для достижения этого эффекта любая фигура должна реализовывать интерфейс IGeometricShape.
3. Легкость добавления других фигур - тоже не совсем понимаю что под этим имеется в виду, но по-моему все достаточно примитивно: реализуем метод интерфейса GetArea() в зависимости от типа новой фигуры и фигура готова.
4. Проверка является ли треугольник прямоугольным - возможно у меня получился какой-то костыль, но я почему-то не придумал, как можно сделать это проще).
5. Юнит-тесты. Честно, я ни разу их не писал и имел лишь небольшое представление о том, что они из себя представляют. Сначала попробовал NUnit, но почему-то он никак не хотел прогонять тесты, поэтому для сравнения подключил XUnit (с ним уже все заработало). Теорию для выполнения задания я особо не читал, разобрался интуитивно. Постарался придумать несколько видов тестов для разных ситуаций (обычное сравнение результата, проверка на исключение, проверка на правду/ложь). Скорее всего, выглядит это коряво, но опять же - я их никогда до этого не писал и не знаю как делать это правильно.
