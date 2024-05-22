import os

def search_for_photoshop_in_directory(directory, found_log_file, not_found_log_file):
    for root, dirs, files in os.walk(directory):
        for file_name in files:
            if file_name.endswith('.bin') or '.' not in file_name:  # Check if the file has a .bin extension or no extension
                file_path = os.path.join(root, file_name)
                if os.path.isfile(file_path):
                    try:
                        with open(file_path, 'r', encoding='utf-8') as f:
                            content = f.read()
                            if 'Photoshop' in content:
                                found_log_file.write(f'{file_path}\n')
                            else:
                                not_found_log_file.write(f'{file_path}\n')
                    except UnicodeDecodeError:
                        try:
                            with open(file_path, 'r', encoding='latin1') as f:
                                content = f.read()
                                if 'Photoshop' in content:
                                    found_log_file.write(f'{file_path}\n')
                                else:
                                    not_found_log_file.write(f'{file_path}\n')
                        except Exception as e:
                            error_message = f'Could not read {file_path}: {str(e)}\n'
                            print(error_message)
                    except PermissionError:
                        error_message = f'Could not read {file_path}: Permission denied\n'
                        print(error_message)

def main():
    directory = input("Enter the directory path to search for Photoshop strings: ")
    found_log_file_path = 'found_log.txt'
    not_found_log_file_path = 'not_found_log.txt'
    
    with open(found_log_file_path, 'w') as found_log_file:
        with open(not_found_log_file_path, 'w') as not_found_log_file:
            search_for_photoshop_in_directory(directory, found_log_file, not_found_log_file)

if __name__ == "__main__":
    main()
