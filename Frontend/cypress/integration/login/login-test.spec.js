describe("Login test", () => {
    it("should visit login page", () =>{
        cy.visit("/");
    })

    it("should not be able to login", () =>{
        cy.get('#emailInput').type('igti@gmail.com');
        cy.get('#passwordInput').type('12345');
        cy.get('#loginButton').click();

        expect(cy.get('#messageNotAllowed')).to.exist;
    })

    it("should be able to login", () =>{
        cy.get('#emailInput').clear().type('igti@gmail.com');
        cy.get('#passwordInput').clear().type('123456');
        cy.get('#loginButton').click();

        cy.get('#messageNotAllowed').should('not.exist');

        cy.url().should('include', '/main/league')
    })
})