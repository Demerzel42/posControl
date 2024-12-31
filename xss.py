from flask import Flask, request

app = Flask(__name__)

@app.route('/xss', methods=['GET'])
def xss():
    # Get user input from query parameter 'userInfo'
    user_info = request.args.get('userInfo', '')

    # Vulnerable to XSS: directly rendering user input without sanitization
    return f"<body>{user_info}</body>"  # Noncompliant: unsanitized user input

if __name__ == '__main__':
    app.run(debug=True)

