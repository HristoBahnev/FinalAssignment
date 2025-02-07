# Store Data Management System

## Objective

Develop a console application to manage store information.

## Features

**1. Store Management**
    ○ **Add** , **remove** , **update** , and **save** store information, including:
       ■ **StoreName** ( _string_ )
       ■ **Location** (validated against a list from an API — see next section)
       ■ **Assigned Types** ( _List<string>_ )
       ■ **Income** ( _decimal_ )
**2. REST API Integration**
    ○ Fetches a list of countries from the REST Countries API using **RestSharp**.
       (https://restcountries.com/v3.1/all?fields=name)
    ○ Ensures stores are assigned valid countries (check by name or common field).
    ○ Typical structure of a country response might be something like:
    ○ You will validate the store’s **Location** against these country names.
       ■
**3. Serialization**
    ○ Saves store data to a JSON file (e.g., stores.json) for persistence.
       (file is provided for deserialization purposes)
    ○ Uses **Newtonsoft.Json** for serialization and deserialization.
**4. Interactive Console Menu**
    ○ User-friendly options to navigate the system:


```
■ Add a store.
■ Remove a store.
■ Assign types (e.g., Retail, Wholesale, Online, etc.).
■ Update income.
■ Save data to the JSON file.
```
**5. Input Validation**
    ○ Ensures **duplicate** entries (based on StoreName) are avoided.
    ○ Validates Income as a positive decimal number.
    ○ Handles invalid inputs gracefully without crashing.
**6. Use of Classes**
    ○ Encapsulates store information in a **Store** class.
    ○ Represents country details using separate classes for clear integration with the
       API.

## Example User Flow

1. **REST API Integration**
    ○ On startup, the application fetches the list of valid countries using RestSharp
       from the REST Countries API.
    ○ It stores or displays these valid locations to help the user pick the correct one.
2. **Adding a Store**
    ○ The user enters:
       ■ StoreName (string)
       ■ Income (decimal)
       ■ Selects a valid Location from the retrieved list of countries.
    ○ The system checks for duplicates (e.g., by StoreName), and if the store is
       unique and all validations pass, it is added to the system.
3. **Remove Store by Name**
    ○ The user specifies a StoreName.
    ○ If found, it is removed from the list of managed stores.
4. **Assigning Types**
    ○ Users can assign one or multiple types (similar to “departments” in the original) to
       a specific store.
    ○ For example, “Grocery”, “Clothing”, “Electronics” could be valid store types.
5. **Updating Income**
    ○ The user provides a StoreName and a new Income value.
    ○ The system validates that the input is a positive decimal and updates the store
       record.
6. **Saving Data**
    ○ At any point, the user can choose “Save data” to serialize all store information
       into stores.json using **Newtonsoft.Json**.


## Success Criteria

1. **Clean and Modular Code**
    ○ Proper use of classes, functions, and data structures to keep the code organized.
2. **Robust Error Handling**
    ○ Gracefully handles invalid user inputs and provides friendly messages.
3. **Effective Use of Third-Party Libraries**
    ○ **RestSharp** for the country API calls.
    ○ **Newtonsoft.Json** for JSON serialization.
4. **Intuitive User Interface**
    ○ Clear and guided console prompts.
    ○ Easy navigation between menu items.


# FinalAssignment
