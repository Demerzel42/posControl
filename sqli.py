from flask import Flask, request
import sqlite3

app = Flask(__name__)

@app.route('/sqli/<id>', methods=['GET'])
def do_sqli(id):
    con_string = "I AM a connection String"  # Connection string placeholder
    conn = None
    result = ""

    try:
        # Establishing a connection (using SQLite in this example)
        conn = sqlite3.connect('example.db')  # Replace with your actual database connection
        cursor = conn.cursor()

        # Vulnerable to SQL injection
        query = "SELECT * FROM users WHERE userId = '" + id + "'"  # Noncompliant
        cursor.execute(query)

        # Fetching the result
        rows = cursor.fetchall()
        for row in rows:
            result += row[1]  # Assuming userName is the second column

    except Exception as e:
        return f"Error: {e}"
    finally:
        if conn:
            conn.close()

    return result


if __name__ == '__main__':
    app.run(debug=True)

