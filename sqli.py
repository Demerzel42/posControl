from flask import Flask, request, render_template_string
import sqlite3

app = Flask(__name__)

# A simple HTML form
HTML = '''
    <html>
        <head>
            <title>Login</title>
            <style>
                body { font-family: Arial, sans-serif; }
                .container { width: 300px; margin: auto; margin-top: 50px; }
                input { margin-bottom: 10px; width: 100%; padding: 10px; }
                button { width: 100%; padding: 10px; }
            </style>
        </head>
        <body>
            <div class="container">
                <h2>Login</h2>
                <form method="post" action="/login">
                    <input type="text" name="username" placeholder="Username">
                    <input type="password" name="password" placeholder="Password">
                    <button type="submit">Login</button>
                </form>
            </div>
        </body>
    </html>
'''

@app.route('/')
def home():
    return HTML

@app.route('/login', methods=['POST'])
def login():
    username = request.form['username']
    password = request.form['password']

    # Unsafe SQL query
    query = "SELECT * FROM users WHERE username = '{}' AND password = '{}'".format(username, password)

    conn = sqlite3.connect('database.db')
    cursor = conn.cursor()
    cursor.execute(query)
    result = cursor.fetchone()
    conn.close()

    if result:
        return "Welcome, {}!".format(username)
    else:
        return "Login failed!"

if __name__ == '__main__':
    app.run(debug=False)
