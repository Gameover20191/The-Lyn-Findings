import itertools
import pydirectinput
import time
import sys

# Keybindings for Dolphin emulator
keybinds = {
    '1': '1',
    '2': '2',
    'A': 'b',
    'B': 'n'
}

def input_code(sequence):
    # Hold down the 'y' and 'u' keys (shift and ctrl respectively)
    pydirectinput.keyDown('y')
    pydirectinput.keyDown('u')

    # Press each key in the sequence based on the keybinds
    for key in sequence:
        pydirectinput.press(keybinds[key])
        time.sleep(0.05)  # Add a small delay between presses
    
    # Release the 'y' and 'u' keys (shift and ctrl respectively)
    pydirectinput.keyUp('y')
    pydirectinput.keyUp('u')

def generate_combinations(start=0):
    # Define the characters to be used
    characters = ['1', '2', 'A', 'B']

    # Generate all possible combinations of length 8
    combinations = itertools.product(characters, repeat=8)

    times = 0
    # Iterate through each combination and input the code
    for combination in itertools.islice(combinations, start, None):
        times += 1
        code = ''.join(combination)
        print(f'Trying code {code} {start + times}')
        input_code(combination)
        
        # Wait for 0.5 seconds before trying the next combination
        time.sleep(0.5)

        # Add periodic breaks to avoid overwhelming the system
        if times % 100 == 0:
            time.sleep(5)  # Pause for 5 seconds every 100 iterations

def sigma_function():
    # Print the signature and ask if the user wants to go back to the main menu
    print("Made by \nGameover201918\nEggscantfly\nDuckymomo360\nChatGPT 4.0")
    while True:
        choice = input("Do you want to go back to the main menu? (Y/N): ").lower()
        if choice in ['y', 'yes']:
            break
        elif choice in ['n', 'no']:
            print("Exiting the program.")
            sys.exit()
        else:
            print("Invalid input. Please enter Y or N.")

def line_skip_function():
    # Ask the user for the starting combination number
    try:
        start = int(input("Enter the starting combination number: "))
        generate_combinations(start=start)
    except ValueError:
        print("Invalid input. Please enter a valid number.")

def main_menu():
    while True:
        print("\n" + "="*40)
        print(" SIGMA FINDER")
        print("="*40)
        print("Menu:")
        print("1. Run")
        print("2. Sigma")
        print("3. Line Skip")
        print("4. Close")
        
        choice = input("Enter your choice (1/2/3/4): ")

        if choice == '1':
            generate_combinations()
        elif choice == '2':
            sigma_function()
        elif choice == '3':
            line_skip_function()
        elif choice == '4':
            print("Closing the program.")
            sys.exit()
        else:
            print("Invalid choice. Please select 1, 2, 3, or 4.")

# Run the main menu
main_menu()
