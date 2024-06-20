# Duplicate File Cleaner

Duplicate File Cleaner is a simple command-line tool written in C# (.NET) that scans a directory for duplicate files based on their SHA-256 hashes and optionally deletes or moves these duplicates to a backup directory.

## Features

- **File Hashing**: Calculates SHA-256 hashes for all files in a specified directory and its subdirectories.
- **Duplicate Detection**: Identifies duplicate files based on their hash values.
- **File Operations**: Supports deleting duplicate files or moving them to a backup directory.
- **Command-Line Interface**: Accepts command-line arguments for directory path, deletion/moving of duplicates, and backup directory location.

## Requirements

- .NET Framework or .NET Core/Runtime environment to execute the compiled executable.
- Access to files and directories specified for scanning and potential file operations.

## Usage

### Command-Line Arguments

- `directoryPath`: The directory to scan for duplicate files.
- `moveDuplicates`: Optional. Specify 'true' to move duplicates to a backup directory (default is 'false').
- `backupDirectory`: Optional. The directory where duplicates will be moved (required if `moveDuplicates` is 'true').

### Examples

- **Delete duplicate files**:
  ```bash
  DublicateFileCleaner.exe "C:\Path\To\Directory"
  ```

- **Move duplicate files to a backup directory**:
  ```bash
  DublicateFileCleaner.exe "C:\Path\To\Directory" true "C:\Path\To\BackupDirectory"
  ```

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Skyl1te/DuplicateFileCleaner.git
   cd DuplicateFileCleaner
   ```

2. **Build the project** (if changes were made):
   ```bash
   dotnet build
   ```

3. **Run the executable**:
   ```bash
   dotnet run -- "C:\Path\To\Directory" [true/false] ["C:\Path\To\BackupDirectory"]
   ```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please create a GitHub issue or submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Developers
### <a href="https://github.com/Skyl1te/">@Skyl1te</a>
