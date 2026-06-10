using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace cows_and_bulls.Controllers
{
    public class GamesController : Controller
    {
        // Пазим тайното число и броя опити в паметта на сървъра, за да не ни трябва база данни
        private static string SecretCode = "";
        private static int MovesCount = 0;
        private static List<string> History = new List<string>();
        private static bool IsGameWon = false;

        // Това се извиква от твоя зелен бутон "Start Game"
        public IActionResult Create()
        {
            // ПРОВЕРКА: Ако потребителят няма акаунт (не е логнат), го пращаме на регистрация
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return Redirect("/Account/Register");
            }

            // Твоят оригинален код без промяна:
            // Нулираме играта и генерираме ново тайно 4-цифрено число с уникални цифри (от 0 до 7)
            MovesCount = 0;
            IsGameWon = false;
            History.Clear();

            var rand = new Random();
            var digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };
            SecretCode = "";

            for (int i = 0; i < 4; i++)
            {
                int idx = rand.Next(digits.Count);
                SecretCode += digits[idx];
                digits.RemoveAt(idx);
            }

            // Директно пренасочваме към екрана за игра
            return RedirectToAction(nameof(Details));
        }

        // Екранът на самата игра
        public IActionResult Details()
        {
            ViewBag.Moves = MovesCount;
            ViewBag.History = History;
            ViewBag.Win = IsGameWon;
            return View();
        }

        // Извиква се, когато играчът въведе число и натисне бутона "Провери"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PlayAction(string userGuess)
        {
            if (string.IsNullOrEmpty(userGuess) || userGuess.Length != 4 || !userGuess.All(char.IsDigit))
            {
                TempData["Error"] = "Въведете точно 4 цифри!";
                return RedirectToAction(nameof(Details));
            }

            int bulls = 0;
            int cows = 0;

            // Логика за преброяване на бикове и крави
            for (int i = 0; i < 4; i++)
            {
                if (userGuess[i] == SecretCode[i])
                {
                    bulls++;
                }
                else if (SecretCode.Contains(userGuess[i]))
                {
                    cows++;
                }
            }

            MovesCount++;

            // Добавяме опита в историята, която ще се покаже на екрана
            History.Insert(0, $"Опит #{MovesCount} | Число: {userGuess} -> 🟢 Бикове: {bulls}, 🔴 Крави: {cows}");

            if (bulls == 4)
            {
                IsGameWon = true;
                TempData["Success"] = $"Честито! Разшифрова кода {SecretCode} успешно от {MovesCount} опита!";
            }

            return RedirectToAction(nameof(Details));
        }
    }
}