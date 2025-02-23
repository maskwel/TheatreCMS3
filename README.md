# TheatreCMS3
 C# and .NET Capstone Project
This is the final project during The Tech Academy Bootcamp.
In this project I was tasked to compleate a few user stories.

# Story 1
The first task I was assigned was styling the home page.
I began by adding the Theatre Vertigo logo.

In CSS, I used display: block along with margins to center the logo vertically. Additionally, I added spacing above and below the logo to separate it from other elements on the page.

Next, I created two columns for the page content. The left column contains a section called “Spotlight,” while the right column houses the “Donations” and “Sponsors” sections. According to the requirements, the left column needed to occupy two-thirds of the available space. To achieve this, I wrapped both columns inside a flex-container and used the flex property to define the proportions of column1 and column2.

For displaying sponsor images in a responsive horizontal row, I utilized the flex-wrap property to ensure they adapted correctly to different screen sizes.

# Story 2
The next task involved displaying the total number of developer names on the Sign-In page. To accomplish this, I wrote a simple JavaScript function using jQuery. The function retrieves the total number of <p> elements inside the <div> with the ID PersonList and assigns this count to a <span> element with the ID countDevs.
