﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Competicao.Domain 
{    
    public class AdversarioEN
    {
        [Key]
        public int advCodigo { get; set; }
        public DateTime advDataInclusao { get; set; }
        public string advNome { get; set; }
        public string advResponsavel { get; set; }
        public int advDDD1 { get; set; }
        public int advTelefone1 { get; set; }
        public int advDDD2 { get; set; }
        public int advTelefone2 { get; set; }
        public int advDDD3 { get; set; }
        public int advTelefone3 { get; set; }
        public bool advComQuadra { get; set; }
        public QuadraEN quadraEN { get; set; }

        public AdversarioEN(string advNome, string advResponsavel, int advDDD1, int advTelefone1, int advDDD2, int advTelefone2, int advDDD3, int advTelefone3, bool advComQuadra, QuadraEN quadraEN)
        {
            ValidateAndSetProperties(advNome, advResponsavel, advDDD1, advTelefone1, advDDD2, advTelefone2, advDDD3, advTelefone3, advComQuadra, quadraEN);
        }

        public void UpdateProperties(string advNome, string advResponsavel, int advDDD1, int advTelefone1, int advDDD2, int advTelefone2, int advDDD3, int advTelefone3, bool advComQuadra, QuadraEN quadraEN)
        {
            ValidateAndSetProperties(advNome, advResponsavel, advDDD1, advTelefone1, advDDD2, advTelefone2, advDDD3, advTelefone3, advComQuadra, quadraEN);
        }

        private void ValidateAndSetProperties(string advNome, string advResponsavel, int advDDD1, int advTelefone1, int advDDD2, int advTelefone2, int advDDD3, int advTelefone3, bool advComQuadra, QuadraEN quadraEN)
        {
            DomainException.When(string.IsNullOrEmpty(advNome), "Nome do Adversário não informado.");
            DomainException.When(string.IsNullOrEmpty(advResponsavel), "Nome do Responsável não informado.");
            DomainException.When(advDDD1 == 0, "DDD não informado.");
            DomainException.When(advTelefone1 == 0, "Telefone não informado.");

            this.advDataInclusao = DateTime.Now;
            this.advNome = advNome;
            this.advResponsavel = advResponsavel;
            this.advDDD1 = advDDD1;
            this.advTelefone1 = advTelefone1;
            this.advDDD2 = advDDD2;
            this.advTelefone2 = advTelefone2;
            this.advDDD3 = advDDD3;
            this.advTelefone3 = advTelefone3;
            this.advComQuadra = advComQuadra;
            this.quadraEN = quadraEN;
        }
    }
}