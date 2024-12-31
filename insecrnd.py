import random
import string

def generate_insecure_password(length=8):
    # Insecure: Using random from the standard library, which is not cryptographically secure
    chars = string.ascii_letters + string.digits + string.punctuation
    return ''.join(random.choice(chars) for _ in range(length))

# Example usage
password = generate_insecure_password()
print(f"Generated password: {password}")

