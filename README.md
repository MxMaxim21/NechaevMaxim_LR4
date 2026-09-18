# Class Library and Integration Tests

Проект представляет собой модульную библиотеку классов для вычисления математических выражений и работы с историей, а также проект модульных тестов с обработкой исключительных ситуаций.

## Структура решения
* **CalculatorLib** — библиотека классов (Class Library):
  * `Interfaces/` — контракты сервисов (`ICalculationService`, `IHistoryService`).
  * `Services/` — реализация логики вычислений и файлового логирования.
  * `Models/` — модели данных (`HistoryItem`).
  * `Exceptions/` — пользовательские классы исключений (`InvalidExpressionException`, `CalculationDivisionByZeroException`).
* **CalculatorTests** — интегрирующий проект модульных тестов (MSTest).

## Требования
* .NET 8.0 SDK (или .NET Framework в зависимости от конфигурации)
* Visual Studio 2022

## Сборка и запуск тестов
1. Откройте файл решения `CalculatorLib.slnx` в Visual Studio.
2. Выполните сборку решения: `Ctrl + Shift + B` (Сборка -> Собрать решение).
3. Откройте Обозреватель тестов: `Тест -> Обозреватель тестов`.
4. Нажмите `Запустить все тесты`.