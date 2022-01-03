using KataExercises;

// Kata_005_Persistence
Console.WriteLine(Kata_005_Persistence.Calculate(999));
Console.WriteLine(Kata_005_PersistenceRecursion.Calculate(999));

// Kata_007_Brace
Console.WriteLine(Kata_007_Brace.ValidBraces("(){}[]"));
Console.WriteLine(Kata_007_Brace.ValidBraces("([{}])"));
Console.WriteLine(Kata_007_Brace.ValidBraces("(}"));
Console.WriteLine(Kata_007_Brace.ValidBraces("[(])"));
Console.WriteLine(Kata_007_Brace.ValidBraces("[({})](]"));
Console.WriteLine(Kata_007_Brace.ValidBraces("(({{[[]]}}))"));

// Kata_009_SimplePigLatin
Console.WriteLine(Kata_009_SimplePigLatin.PigIt("Pig latin is cool\nThis is my string\nHello world !"));
Console.WriteLine(Kata_009_SimplePigLatin.PigIt("world! this"));

// Kata_010_FindTheParityOutlier
Console.WriteLine(Kata_010_FindTheParityOutlier.Find(new int[] { 1, 3, 5, 6, 7, 9 }));
Console.WriteLine(Kata_010_FindTheParityOutlier.Find(new int[] { 2, 4, 0, 100, 4, 11, 2602, 36 }));
Console.WriteLine(Kata_010_FindTheParityOutlier.Find(new int[] { 160, 3, 1719, 19, 11, 13, -21 }));

// Kata_011_BuildAPileOfCubes
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(36) + " expected 3");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(1071225) + " expected 45");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(91716553919377) + " expected -1");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(4183059834009) + " expected 2022");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(24723578342962) + " expected -1");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(135440716410000) + " expected 4824");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(1731515567531422500) + " expected -1");
Console.WriteLine(Kata_011_BuildAPileOfCubes.FindNb2(2238723532263439936) + " expected -1");