import requests
import json
import random
import uuid
import pandas as pd
from faker import Faker

fake = Faker()

# Base URL of the API
host = "http://localhost:5219/"

# Number of dummy entries to create
num_entries = 1000

# Endpoint paths
add_employee_endpoint = f"{host}Auth/AddEmployee"
add_education_endpoint = f"{host}Auth/AddEducationalBackground/"
add_employment_endpoint = f"{host}Auth/AddEmploymentHistory/"
add_skills_endpoint = f"{host}Auth/AddSkills/"
add_reference_endpoint = f"{host}Auth/AddReference/"

# Data list to save in Excel
data = []

def create_dummy_employee():
    employee_id = str(uuid.uuid4())

    # Personal and contact information
    personal_info = {
        "PersonalInformation": {
            "FullName": fake.name(),
            "DateOfBirth": fake.date_of_birth(minimum_age=18, maximum_age=65).isoformat(),
            "PlaceOfBirth": fake.city(),
            "Gender": random.choice(["Male", "Female"]),
            "CivilStatus": random.choice(["Single", "Married"]),
            "Citizenship": fake.country(),
            "Height": random.randint(150, 200),
            "Weight": random.randint(50, 100),
            "BloodType": random.choice(["A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"])
        },
        "ContactInformation": {
            "PhoneNumber": fake.phone_number(),
            "MobileNumber": fake.phone_number(),
            "EmailAddress": fake.email(),
            "PermanentAddress": fake.address(),
            "PresentAddress": fake.address()
        },
        "Password": fake.password()
    }

    # Post personal and contact information
    response = requests.post(add_employee_endpoint, headers={"Content-Type": "application/json"}, data=json.dumps(personal_info))
    if response.status_code == 200:
        print(f"Added employee: {personal_info['PersonalInformation']['FullName']}")

        # Add the employee details to the data list
        data.append({
            "EmployeeID": employee_id,
            "FullName": personal_info['PersonalInformation']['FullName'],
            "DateOfBirth": personal_info['PersonalInformation']['DateOfBirth'],
            "PlaceOfBirth": personal_info['PersonalInformation']['PlaceOfBirth'],
            "Gender": personal_info['PersonalInformation']['Gender'],
            "CivilStatus": personal_info['PersonalInformation']['CivilStatus'],
            "Citizenship": personal_info['PersonalInformation']['Citizenship'],
            "Height": personal_info['PersonalInformation']['Height'],
            "Weight": personal_info['PersonalInformation']['Weight'],
            "BloodType": personal_info['PersonalInformation']['BloodType'],
            "PhoneNumber": personal_info['ContactInformation']['PhoneNumber'],
            "MobileNumber": personal_info['ContactInformation']['MobileNumber'],
            "EmailAddress": personal_info['ContactInformation']['EmailAddress'],
            "PermanentAddress": personal_info['ContactInformation']['PermanentAddress'],
            "PresentAddress": personal_info['ContactInformation']['PresentAddress'],
            "Password": personal_info['Password']
        })

    # Educational background
    education_info = {
        "Degree": "Computer Science",
        "School": fake.company(),
        "YearGraduated": str(random.randint(1990, 2020))
    }

    response = requests.post(f"{add_education_endpoint}{employee_id}", headers={"Content-Type": "application/json"}, data=json.dumps(education_info))
    if response.status_code == 200:
        print(f"Added educational background for {employee_id}")

    # Employment history
    employment_info = {
        "Employer": fake.company(),
        "Position": "Software Engineer",
        "StartDate": fake.date_between(start_date='-10y', end_date='-5y').isoformat(),
        "EndDate": fake.date_between(start_date='-4y', end_date='today').isoformat()
    }

    response = requests.post(f"{add_employment_endpoint}{employee_id}", headers={"Content-Type": "application/json"}, data=json.dumps(employment_info))
    if response.status_code == 200:
        print(f"Added employment history for {employee_id}")

    # Skills
    skills_info = {
        "Skill": "Programming",
        "Language": random.choice(["Java", "Python", "C#", "JavaScript", "Ruby", "Go"])
    }

    response = requests.post(f"{add_skills_endpoint}{employee_id}", headers={"Content-Type": "application/json"}, data=json.dumps(skills_info))
    if response.status_code == 200:
        print(f"Added skills for {employee_id}")

    # References
    reference_info = {
        "Name": fake.name(),
        "ContactInformation": fake.phone_number()
    }

    response = requests.post(f"{add_reference_endpoint}{employee_id}", headers={"Content-Type": "application/json"}, data=json.dumps(reference_info))
    if response.status_code == 200:
        print(f"Added reference for {employee_id}")

# Generate and post 10000 dummy entries
for _ in range(num_entries):
    create_dummy_employee()

# Save the data to an Excel file
df = pd.DataFrame(data)
df.to_excel("dummy_employees.xlsx", index=False)

print("Data saved to dummy_employees.xlsx")
