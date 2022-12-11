# Maze Generator
Making a maze generator in Unity with C# as a part of an assessment task for an internship position.

## Getting Started

These instructions will help you get the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [Unity](https://unity.com/)
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

### Installing

1. Clone or download the repository

```
git clone https://github.com/n-c0de-r/MazeGenerator.git
```

2. Open the project in Unity

3. Attach the `MazeGenerator` script to an empty GameObject in your Unity project

4. Call the `GenerateMaze()` function to generate the maze

```cs
MazeGenerator mazeGenerator = new MazeGenerator(sizeX, sizeY);
mazeGenerator.GenerateMaze();
```

5. Use the `maze` array to display the maze in the Unity scene

```cs
int[,] maze = mazeGenerator.maze;
```

## Built With

- [Unity](https://unity.com/) - Game engine and development platform
- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - Programming language

## Contributing

If you want to contribute to the project, please follow these guidelines:

- Fork the repository
- Create a new branch (`git checkout -b my-feature`)
- Commit your changes (`git commit -am 'Add some feature'`)
- Push the branch (`git push origin my-feature`)
- Create a new Pull Request

## Authors

- [**n-c0de-r**](https://github.com/n-c0de-r)

## License

This project is not licensed under any particular license.

## Acknowledgments

- [Wikipedia](https://en.wikipedia.org/wiki/Maze_generation_algorithm) - Provided link in the assessment task
- [Stack Overflow](https://stackoverflow.com/questions/38502/whats-a-good-algorithm-to-generate-a-maze) - For hinting at Jamis Buck
- [Jamis Buck - GitHub](https://github.com/jamis) - This guy is an institution on mazes
- [Jamis Buck - Maze Blog](https://weblog.jamisbuck.org/2011/2/7/maze-generation-algorithm-recap) - His visual representation helped me pick the right idea
- [Youtube - showing some algorithms](https://www.youtube.com/watch?v=sVcB8vUFlmU)
- [Youtube - some more algorithms vizualized](https://www.youtube.com/watch?v=U3meEXvYFsc)

## Screenshots

![Maze](screenshots/maze.png)

A maze generated using the `MazeGenerator` script.