describe("Login test", () => {
    beforeEach(() => {
        cy.clearLocalStorage();
    })
    it("should visit login page", () =>{
        cy.visit("/");
    })

    it("should not be able to login", () =>{
        cy.visit("/");

        cy.get('[data-cy=emailInput]').type('igti@gmail.com');
        cy.get('[data-cy=passwordInput]').type('12345');
        cy.get('[data-cy=loginButton]').click();

        expect(cy.get('[data-cy=messageNotAllowed]')).to.exist;
    })

    it("should be able to login", () =>{
        cy.visit("/");

        cy.get('[data-cy=emailInput]').clear().type('igti@gmail.com');
        cy.get('[data-cy=passwordInput]').clear().type('123456');
        cy.get('[data-cy=loginButton]').click();

        cy.get('[data-cy=messageNotAllowed]').should('not.exist');

        cy.url().should('include', '/main/league')
    })

    it("should be able to logout", () =>{
        cy.visit("/login");
        
        cy.get('[data-cy=emailInput]').clear().type('igti@gmail.com');
        cy.get('[data-cy=passwordInput]').clear().type('123456');
        cy.get('[data-cy=loginButton]').click();

        cy.get('[data-cy=logoutButton]').click();

        cy.url().should('include', '/login')
        cy.get('[data-cy=messageNotAllowed]').should('not.exist');
    })
})
