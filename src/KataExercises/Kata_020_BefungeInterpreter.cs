﻿//Esoteric languages are pretty hard to program, but it's fairly interesting to write interpreters for them!

//Your task is to write a method which will interpret Befunge-93 code! Befunge-93 is a language in which the code is presented not as a series of instructions, but as instructions scattered on a 2D plane; your pointer starts at the top-left corner and defaults to moving right through the code. Note that the instruction pointer wraps around the screen! There is a singular stack which we will assume is unbounded and only contain integers. While Befunge-93 code is supposed to be restricted to 80x25, you need not be concerned with code size. Befunge-93 supports the following instructions (from Wikipedia):

//0 - 9 Push this number onto the stack.
//+ Addition: Pop a and b, then push a+b.
//  - Subtraction: Pop a and b, then push b-a.
//  * Multiplication: Pop a and b, then push a* b.
/// Integer division: Pop a and b, then push b/a, rounded down. If a is zero, push zero.
//% Modulo: Pop a and b, then push the b%a.If a is zero, push zero.
//! Logical NOT: Pop a value.If the value is zero, push 1; otherwise, push zero.
//` (backtick) Greater than: Pop a and b, then push 1 if b>a, otherwise push zero.
//> Start moving right.
//< Start moving left.
//^ Start moving up.
//v Start moving down.
//? Start moving in a random cardinal direction.
//_ Pop a value; move right if value = 0, left otherwise.
//| Pop a value; move down if value = 0, up otherwise.
//" Start string mode: push each character's ASCII value all the way up to the next ".
//: Duplicate value on top of the stack. If there is nothing on top of the stack, push a 0.
//\ Swap two values on top of the stack. If there is only one value, pretend there is an extra 0 on bottom of the stack.
//$ Pop value from the stack and discard it.
//. Pop value and output as an integer.
//, Pop value and output the ASCII character represented by the integer code that is stored in the value.
//# Trampoline: Skip next cell.
//p A "put" call (a way to store a value for later use). Pop y, x and v, then change the character at the position (x,y) in the program to the character with ASCII value v.
//g A "get" call (a way to retrieve data in storage). Pop y and x, then push ASCII value of the character at that position in the program.
//@ End program.
//(i.e. a space) No-op. Does nothing.
//The above list is slightly modified: you'll notice if you look at the Wikipedia page that we do not use the user input instructions and dividing by zero simply yields zero.

//Here's an example:

//>987v>.v
//  v456<  :
//>321 ^ _@
//will create the output 123456789.

//So what you must do is create a function such that when you pass in the Befunge code, the function returns the output that would be generated by the code. So, for example:

//"123456789".equals(new BefungeInterpreter().interpret(">987v>.v\nv456<  :\n>321 ^ _@")

namespace KataExercises;

public class Kata_020_BefungeInterpreter
{
    public string Interpret(string code)
    {
        var rnd = new Random();

        var rows = code.Split('\n');

        var result = string.Empty;

        int rowIndex = 0;
        int columnIndex = 0;

        var currentCommand = rows[rowIndex][columnIndex];
        var stack = new Stack<int>();

        var movingDirection = '>';
        var isStringMode = false;

        while (currentCommand != '@')
        {
            if (isStringMode)
            {
                if (currentCommand == '"')
                {
                    isStringMode = false;
                }
                else
                {
                    stack.Push(currentCommand);
                }
            }
            else
            {
                switch (currentCommand)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9': // 0 - 9 Push this number onto the stack.
                        {
                            stack.Push(int.Parse(currentCommand.ToString()));
                            break;
                        }
                    case '+': // + Addition: Pop a and b, then push a+b.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();
                            stack.Push(a + b);
                            break;
                        }
                    case '-': // - Subtraction: Pop a and b, then push b-a.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();
                            stack.Push(b - a);
                            break;
                        }
                    case '*': // * Multiplication: Pop a and b, then push a*b.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();
                            stack.Push(a * b);
                            break;
                        }
                    case '/': // / Integer division: Pop a and b, then push b/a, rounded down. If a is zero, push zero.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();

                            if (a == 0)
                            {
                                stack.Push(0);
                            }
                            else
                            {
                                stack.Push(b / a);
                            }
                            break;
                        }
                    case '%': // % Modulo: Pop a and b, then push the b%a. If a is zero, push zero.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();

                            if (a == 0)
                            {
                                stack.Push(0);
                            }
                            else
                            {
                                stack.Push(b % a);
                            }
                            break;
                        }
                    case '!': // ! Logical NOT: Pop a value. If the value is zero, push 1; otherwise, push zero.
                        {
                            var a = stack.Pop();
                            if (a == 0)
                            {
                                stack.Push(1);
                            }
                            else
                            {
                                stack.Push(0);
                            }
                            break;
                        }
                    case '`': // ` (backtick) Greater than: Pop a and b, then push 1 if b>a, otherwise push zero.
                        {
                            var a = stack.Pop();
                            var b = stack.Pop();

                            if (b > a)
                            {
                                stack.Push(1);
                            }
                            else
                            {
                                stack.Push(0);
                            }
                            break;
                        }
                    case '>': // > Start moving right.
                    case '<': // < Start moving left.
                    case '^': // ^ Start moving up.
                    case 'v': // v Start moving down.
                        {
                            movingDirection = currentCommand;
                            break;
                        }
                    case '?': // ? Start moving in a random cardinal direction.
                        {
                            var direction = rnd.Next(4);
                            switch (direction)
                            {
                                case 0:
                                    movingDirection = '>';
                                    break;
                                case 1:
                                    movingDirection = '<';
                                    break;
                                case 2:
                                    movingDirection = '^';
                                    break;
                                default:
                                    movingDirection = 'v';
                                    break;
                            }
                            break;
                        }
                    case '_': // _ Pop a value; move right if value = 0, left otherwise.
                        {
                            var a = stack.Pop();
                            movingDirection = a == 0 ? '>' : '<';

                            break;
                        }
                    case '|': // | Pop a value; move down if value = 0, up otherwise.
                        {
                            var a = stack.Pop();
                            movingDirection = a == 0 ? 'v' : '^';

                            break;
                        }
                    case '"': // Start string mode: push each character's ASCII value all the way up to the next ".
                        {
                            isStringMode = !isStringMode;
                            break;
                        }
                    case ':': // : Duplicate value on top of the stack. If there is nothing on top of the stack, push a 0.
                        {
                            if (stack.Count > 0)
                            {
                                var a = stack.Peek();
                                stack.Push(a);
                            }
                            else
                            {
                                stack.Push(0);
                            }
                            break;
                        }
                    case '\\': // \ Swap two values on top of the stack. If there is only one value, pretend there is an extra 0 on
                        {
                            if (stack.Count == 1)
                            {
                                stack.Push(0);
                            }
                            else
                            {
                                var a = stack.Pop();
                                var b = stack.Pop();

                                stack.Push(a);
                                stack.Push(b);
                            }

                            break;
                        }
                    case '$': // $ Pop value from the stack and discard it.
                        {
                            var _ = stack.Pop();
                            break;
                        }
                    case '.': // . Pop value and output as an integer.
                        {
                            var a = stack.Pop();
                            result += a;
                            break;
                        }
                    case ',': // , Pop value and output the ASCII character represented by the integer code that is stored in the value.
                        {
                            var a = stack.Pop();
                            result += (char)a;
                            break;
                        }
                    case '#': // Trampoline: Skip next cell.
                        {
                            Move();
                            break;
                        }
                    case 'p': // A "put" call (a way to store a value for later use). Pop y, x and v,
                              // then change the character at the position (x,y) in the program to the character with ASCII value v.
                        {
                            var y = stack.Pop();
                            var x = stack.Pop();
                            var v = stack.Pop();
                            var r = rows[y];
                            rows[y] = r.Remove(x, 1).Insert(x, ((char)v).ToString());

                            break;
                        }
                    case 'g': // g A "get" call (a way to retrieve data in storage). Pop y and x,
                              // then push ASCII value of the character at that position in the program.
                        {
                            var y = stack.Pop();
                            var x = stack.Pop();

                            var a = rows[y][x];
                            stack.Push(a);

                            break;
                        }
                    case ' ':
                        {
                            break;
                        }
                    case '@':
                    default:
                        break;
                }
            }

            Move();
            currentCommand = rows[rowIndex][columnIndex];
        }

        return result;

        void Move()
        {
            switch (movingDirection)
            {
                case '>':
                    columnIndex++;
                    if (columnIndex > rows[rowIndex].Length - 1)
                    {
                        columnIndex = 0;
                    }
                    break;
                case '<':
                    columnIndex--;
                    if (columnIndex < 0)
                    {
                        columnIndex = rows[rowIndex].Length - 1;
                    }
                    break;
                case '^':
                    rowIndex--;
                    if (rowIndex < 0)
                    {
                        rowIndex = rows.Length - 1;
                    }
                    break;
                case 'v':
                    rowIndex++;
                    if (rowIndex > rows.Length - 1)
                    {
                        rowIndex = 0;
                    }
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
